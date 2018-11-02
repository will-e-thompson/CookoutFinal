using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

#if OFFLINE_SYNC_ENABLED
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
#endif

namespace Cookout
{
    public partial class RegistrationManager
    {
        static RegistrationManager defaultInstance = new RegistrationManager();
        MobileServiceClient client;


#if OFFLINE_SYNC_ENABLED
        IMobileServiceSyncTable<UserRegistration> todoTable;
#else
        IMobileServiceTable<UserRegistration> userTable;
#endif

        const string offlineDbPath = @"localstore.db";

        private RegistrationManager()
        {

            this.client = new MobileServiceClient(Constants.ApplicationURL);
#if OFFLINE_SYNC_ENABLED
            var store = new MobileServiceSQLiteStore(offlineDbPath);
            store.DefineTable<UserRegistration>();

            //Initializes the SyncContext using the default IMobileServiceSyncHandler.
            this.client.SyncContext.InitializeAsync(store);

            this.userTable = client.GetSyncTable<UserRegistration>();
#else
            this.userTable = client.GetTable<UserRegistration>();
#endif
        }

        public static RegistrationManager DefaultManager
        {
            get
            {
                return defaultInstance;
            }
            private set
            {
                defaultInstance = value;
            }
        }

        public MobileServiceClient CurrentClient
        {
            get { return client; }
        }

        public bool IsOfflineEnabled
        {
            get { return userTable is Microsoft.WindowsAzure.MobileServices.Sync.IMobileServiceSyncTable<UserRegistration>; }
        }

        public async Task<ObservableCollection<UserRegistration>> IsUserValid(string email, bool syncItems = false)
        {
            try
            {
#if OFFLINE_SYNC_ENABLED
                if (syncItems)
                {
                    await this.SyncAsync();
                }
#endif

                IEnumerable<UserRegistration> items = await userTable
                    .Where(singleuser => singleuser.Email == email)
                    .ToEnumerableAsync();

                return new ObservableCollection<UserRegistration>(items);
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine("Invalid sync operation: {0}", new[] { msioe.Message });
            }
            catch (Exception e)
            {
                Debug.WriteLine("Sync error: {0}", new[] { e.Message });
            }
            return null;
        }



        public async Task<ObservableCollection<UserRegistration>> GetPassword(string email, bool syncItems = false)
        {
            try
            {
#if OFFLINE_SYNC_ENABLED
                if (syncItems)
                {
                    await this.SyncAsync();
                }
#endif

                IEnumerable<UserRegistration> items = await userTable
                    .Where(singleuser => singleuser.Email == email)
                    .Select(ee=>ee)
                    .ToEnumerableAsync();
                    
                return new ObservableCollection<UserRegistration>(items);


            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine("Invalid sync operation: {0}", new[] { msioe.Message });
            }
            catch (Exception e)
            {
                Debug.WriteLine("Sync error: {0}", new[] { e.Message });
            }
            return null;
        }



        public async Task SaveTaskAsync(UserRegistration item)
        {
            try
            {
                if (item.Id == null)
                {
                    await userTable.InsertAsync(item);
                }
                else
                {
                    await userTable.UpdateAsync(item);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Save error: {0}", new[] { e.Message });
            }
        }







#if OFFLINE_SYNC_ENABLED
        public async Task SyncAsync()
        {
            ReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;

            try
            {
                await this.client.SyncContext.PushAsync();

                await this.todoTable.PullAsync(
                    //The first parameter is a query name that is used internally by the client SDK to implement incremental sync.
                    //Use a different query name for each unique query in your program
                    "allTodoItems",
                    this.todoTable.CreateQuery());
            }
            catch (MobileServicePushFailedException exc)
            {
                if (exc.PushResult != null)
                {
                    syncErrors = exc.PushResult.Errors;
                }
            }

            // Simple error/conflict handling. A real application would handle the various errors like network conditions,
            // server conflicts and others via the IMobileServiceSyncHandler.
            if (syncErrors != null)
            {
                foreach (var error in syncErrors)
                {
                    if (error.OperationKind == MobileServiceTableOperationKind.Update && error.Result != null)
                    {
                        //Update failed, reverting to server's copy.
                        await error.CancelAndUpdateItemAsync(error.Result);
                    }
                    else
                    {
                        // Discard local change.
                        await error.CancelAndDiscardItemAsync();
                    }

                    Debug.WriteLine(@"Error executing sync operation. Item: {0} ({1}). Operation discarded.", error.TableName, error.Item["id"]);
                }
            }
        }
#endif
    }
}

