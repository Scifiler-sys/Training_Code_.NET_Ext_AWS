//Global using so that any c# classes we make inside this project will implicitly start using PokeModel
global using PokeModel;


/*
    Data Layer project is responsible for directly accessing our database and doing any CRUD operations we want to it
    CRUD?
    Create resources
    Delete resources
    Read resources
    Update resources
*/
namespace PokeDL
{
    /*
        We create an interface first to follow abstraction
        More importantly, it is also to follow dependency injection design pattern (which we will cover later)
    */
    public interface IRepository<T>
    {
        /// <summary>
        /// Will add a resource to the database
        /// </summary>
        /// <param name="p_resource">The resource that will be added</param>
        /// <returns>Saved pokemon</returns>
        T Add(T p_resource);

        /// <summary>
        /// Will get all the resource in the database
        /// </summary>
        /// <returns>List of resource</returns>
        List<T> GetAll();

        /// <summary>
        /// Will update an existing resource to the database
        /// </summary>
        /// <param name="p_resource">Changed values of the resource</param>
        /// <returns>Updated resource</returns>
        T Update(T p_resource);

        /// <summary>
        /// Will delete a resource to the database
        /// </summary>
        /// <param name="p_resource">The resource being deleted</param>
        /// <returns>Deleted resource</returns>
        T Delete(T p_resource);
    }
}