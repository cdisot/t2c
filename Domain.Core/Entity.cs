using System;

namespace Domain.Core
{
    public abstract class Entity:IEntity
    {
        #region Properties

        
        /// <summary>
        /// Unique Identification property
        /// </summary>
        public virtual Guid Id { get; set; }

        ///// <summary>
        ///// Auto-numeric property for identification with SEO and humans
        ///// </summary>
        //public virtual int HumanId { get; internal protected set; }

        public virtual string Name { get; set; }

        #endregion


    }
}