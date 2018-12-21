using Microsoft.Extensions.Localization;
using System;

namespace JsonResourceLocalizerLibrary.Localizers
{
    /// <summary>
    /// Class for retrieving the messages from resource files and handing them over to requester.
    /// </summary>
    public class StringLocalizerService : IStringLocalizerService
    {
        private readonly IStringLocalizerFactory _factory;

        public StringLocalizerService()
        {
        }

        public StringLocalizerService(IStringLocalizerFactory factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Gets the localized version of the string based on the MessageType ans key passed
        /// </summary>
        /// <param name="type">Type of Resource</param>
        /// <param name="key">Key for which the values is requested</param>
        /// <param name="keyInValueRequired">True if Key is also needed in return else False</param>
        /// <returns></returns>
        public string GetLocalizedString(Type type, string key)
        {
            var localizer = GetStringLocalizer(type);
            return localizer[key];
        }
        /// <summary>
        /// returns the IStringLocalizer based on the MessageType passed
        /// </summary>
        /// <param name="type">Type of Resource to be looked for</param>
        /// <returns></returns>
        private IStringLocalizer GetStringLocalizer(Type type)
        {
            return _factory.Create(type);           
        }
    }
}
