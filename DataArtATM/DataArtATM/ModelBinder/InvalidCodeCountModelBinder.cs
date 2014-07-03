namespace DataArtATM.ModelBinder
{
    using System;
    using System.Web.Mvc;

    /// <summary>
    /// The invalid code count model binder.
    /// </summary>
    public class InvalidCodeCountModelBinder : IModelBinder
    {
        /// <summary>
        /// The bind model.
        /// </summary>
        /// <param name="controllerContext">
        /// The controller context.
        /// </param>
        /// <param name="bindingContext">
        /// The binding context.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// The exception is returned when session is null.
        /// </exception>
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var session = controllerContext.HttpContext.Session;
            if (session == null)
            {
                throw new ArgumentNullException("controllerContext", "Session is null");
            }

            var codeCount = session["InvalidCodeCount"];
            int invalidCodeCount = codeCount == null ? 1 : int.Parse(codeCount.ToString());

            return invalidCodeCount;
        }
    }
}