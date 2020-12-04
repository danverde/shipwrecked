using Shipwreck.Model.Items;

namespace Shipwreck.Model.Factories
{
    class ResourceFactory
    {
        public Resource GetResource(ResourceType resourceType)
        {
            var resource = new Resource
            {
                Droppable = true,
                ResourceType = resourceType
            };
            
            switch(resourceType)
            {
                case ResourceType.Branch:
                    resource.Name = "Branch";
                    resource.Description = "A sturdy tree branch";
                    break;
                case ResourceType.Match:
                    resource.Name = "Match";
                    resource.Description = "A waterproof match";
                    break;
                case ResourceType.SharpStone:
                    resource.Name = "Sharp Stone";
                    resource.Description = "A sharpened stone";
                    break;
                case ResourceType.Stone:
                    resource.Name = "Sharp Stone";
                    resource.Description = "A rock";
                    break;
                case ResourceType.Vine:
                    resource.Name = "Vine";
                    resource.Description = "A bundle of jungle vines";
                    break;
            }
        
            return resource;
        }
    }
}
