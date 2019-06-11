# TheOnePool
Elegant Object Pooling Solition for the  Unity3d GameEngine that allows for multiple object pools to be managed by one script

	# TheOnePool -Properties
		instance  -  static property that allows for TheOnePool to be accessed in other script without a reference needed in the inspector
		objectPools - contains an array of object pools with a variable size set in the inspector. The size defaults to 1 when added the script is attached to a game object.

	# ObjectPool -Properties
		poolName - optional string that lets you get objects from a pool by the poolName. 
		pooledObject - GameObject Variable for the object you with to pool
		poolSize - int describing the initial size of the pool, if the pool is resized, this value is also adjusted
		canResize - bool to resize the pool is all the objects in the pool are currently in use, this option is enabled by default

	# TheOnePool -Methods
		GetObjectOutOfPool(int pool)
			using an int specifiying the index in the Object Pool Array, Returns an activated object from the arrayed Object Pools.
		GetObjectOutOfPool(int pool, Vector3 pos, Quaternion rot)
			using an int specifiying the index in the Object Pool Array, Returns activated object from the arrayed Object Pools and sets its transform.
		GetObjectOutOfPool(string poolName, Vector3 pos, Quaternion rot)
				using a string specifiying the name of the Object Pool, Returns activated object from the arrayed Object Pools and sets its transform.

Notes-
All returned objects are set to active.
if no object is available in a pool:
	(default)if canResize is set to true, then a new object wil be created, added to the pool list, and returned by the method. 
	(alternative)if canResize is set to false, then the method will return null. 
