using MicroOrm.Pocos.SqlGenerator.Attributes;

namespace Dapper.DataRepositories.Demo.Models
{
    /// <summary>
    /// 
    /// </summary>
    public enum UserStatus : byte
    {
        Active = 1,

        Inactive = 2,

        [Deleted] // This means that rows with this status value are logically deleted
        Deleted = 3
    }

    [StoredAs("Users")]
    public class User
    {
        /// <summary>
        /// 
        /// </summary>
        [KeyProperty(Identity=true)]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [NonStored] // This means this property does not have to be part of the queries generated automatically
        public string FullName
        {
            get 
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [StatusProperty] // This means this property will be used as the status property for each instance
        public UserStatus Status { get; set; }
    }
}