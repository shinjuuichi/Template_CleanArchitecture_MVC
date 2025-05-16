using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers.Abstractions
{
    public abstract class CrudController<Entity> : GetController
    {
        public abstract Task<IActionResult> Create(Entity entity);

        public abstract Task<IActionResult> Edit(Entity entity);

        public abstract Task<IActionResult> Delete(int id);
    }
}
