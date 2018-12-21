using System;

namespace JsonResourceLocalizerLibrary.Localizers
{
    /// <summary>
    /// Interface for defining the contract for handling the messages viz. Info, warning, error etc from api.
    /// </summary>
    public interface IStringLocalizerService
    {
        /// <summary>
        /// Gets the localized version of the string based on the MessageType ans key passed
        /// </summary>
        /// <param name="type">Type of message</param>
        /// <param name="key">Key</param>
        /// <returns></returns>
        string GetLocalizedString(Type type, string key);
    }
}
