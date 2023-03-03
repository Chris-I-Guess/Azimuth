namespace Azimuth.GameObjects
{
	public static class GameObjectManager
	{
		private static List<GameObject> gameObjects = new List<GameObject>();

		public static void Add(GameObject _gameObject)
		{
			if(!gameObjects.Contains(_gameObject))
			{
				gameObjects.Add(_gameObject);
				_gameObject.Load();
			}
		}

		public static void Remove(GameObject _gameObject)
		{
			if(gameObjects.Contains(_gameObject))
			{
				_gameObject.Unload();
				gameObjects.Remove(_gameObject);
			}
		}

		public static void Clear()
		{
			while(gameObjects.Count > 0)
			{
				Remove(gameObjects[0]);
			}
		}
		

		public static void Update(float _deltaTime)
		{
			foreach(GameObject gameObject in gameObjects)
				gameObject.Update(_deltaTime);
		}

		public static void Draw()
		{
			foreach(GameObject gameObject in gameObjects)
				gameObject.Draw();
		}
	}
}