using Shipwreck.Model.Items;

namespace Shipwreck.Model.Factories
{
    class ResourceFactory
    {
        public Resource GetResource(Resource.Type type)
        {
            Resource resource = null;
            switch(type)
            {
                case Resource.Type.Branch:
                    resource = new Resource("Branch", "A sturdy tree branch");
                    break;
                case Resource.Type.Match:
                    resource = new Resource("Match", "A waterproof match");
                    break;
                case Resource.Type.SharpStone:
                    resource = new Resource("Branch", "A sharpened stone");
                    break;
                case Resource.Type.Stone:
                    resource = new Resource("Stone", "A rock");
                    break;
                case Resource.Type.Vine:
                    resource = new Resource("Vine", "A bundle of jungle vines");
                    break;
            }

            return resource;
        }
    }
}
