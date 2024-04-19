using System;

namespace Domain.Core
{
    public interface IEntity
    {
        #region Properties


        /// <summary>
        /// Unique Identification property
        /// </summary>
        Guid Id { get; set; }

        ///// <summary>
        ///// Auto-numeric property for identification with SEO and humans
        ///// </summary>
        //int HumanId { get; set; }

        string Name { get; set; }

        #endregion

    }
}