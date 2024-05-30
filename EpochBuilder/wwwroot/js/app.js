// Functions for Indexed Database

// Initialize the Database
export function initialize(dbName, dbVersion)
{
    let blazorSchoolIndexedDb = indexedDB.open(dbName, dbVersion);
    blazorSchoolIndexedDb.onupgradeneeded = function ()
    {
        let db = blazorSchoolIndexedDb.result;
        db.createObjectStore("worlds", { keyPath: "id" });
    }
}

// Set Database values
export function set(collectionName, value, dbName, dbVersion)
{
    let blazorSchoolIndexedDb = indexedDB.open(dbName, dbVersion);

    blazorSchoolIndexedDb.onsuccess = () => {
        let transaction = blazorSchoolIndexedDb.result.transaction(collectionName, "readwrite");
        let collection = transaction.objectStore(collectionName)
        collection.put(value);
    }
}

export async function get(collectionName, id, dbName, dbVersion)
{
    let request = new Promise((resolve) =>
    {
        let blazorSchoolIndexedDb = indexedDB.open(dbName, dbVersion);
        blazorSchoolIndexedDb.onsuccess = function ()
        {
            let transaction = blazorSchoolIndexedDb.result.transaction(collectionName, "readonly");
            let collection = transaction.objectStore(collectionName);
            let result = collection.get(id);

            result.onsuccess = e => {
                resolve(result.result);
            }
        }
    });

    return await request;
}