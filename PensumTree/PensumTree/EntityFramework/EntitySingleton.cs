namespace PensumTree.EntityFramework
{
    public sealed class EntitySingleton
    {
        private readonly static pensumEntities context = new pensumEntities();
        private EntitySingleton()
        {

        }

        public static pensumEntities Context
        {
            get { return EntitySingleton.context; }
        }
    }
}
