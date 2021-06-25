using System;
using Microsoft.EntityFrameworeCore;

namespace RRTests
{
    public class RepoTest
    {
        /*
            Unit testing in DB needs Microsoft.EntityFrameworkCore.Sqlite package
            Sqlite has features that allows us to create inmemory rdb to test our repo

            We will also need Microsoft.EntityFrameworkCore.Design
        */

        //readonly non-access modifier indicates that the fields are read only
        private readonly DBContextOptions<SPDBContext> options;

        public RepoTest()
        {
            //Gets the configurations for the inmemory rdb we have created
            options = new DBContextOptionsBuilder<SPDBContext>().UseSql("FileName = Test.db").Options;
        }
    }
}