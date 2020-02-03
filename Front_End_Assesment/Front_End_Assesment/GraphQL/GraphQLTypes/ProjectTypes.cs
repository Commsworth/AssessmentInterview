using Front_End_Assesment.Payload;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Front_End_Assesment.GraphQL.GraphQLTypes
{
    public class ProjectType : ObjectGraphType<CreateProjectPayload>
    {
        public ProjectType()
        {
            Name = "CreateProjectType";
            Description = "Create project";
            Field(x => x.Title).Description("Title of Project");
            Field(x => x.Budget).Description("Project Budget");
            Field(x => x.startDate).Description("Startdate for the project");
            Field(x => x.endDate).Description("endate for the project");
            Field(x => x.contractorName).Description("Contractor name for the project");
            Field(x => x.contractorAddress).Description("Contractor address for the project");
        }
    }

    public class LoginType : ObjectGraphType<loginPayload>
    {
        public LoginType()
        {
            Name = "LoginType";
            Description = "Login into the application";
            Field(x => x.email).Description("Email to log into the app hello@commsworth.com");
            Field(x => x.password).Description("Password to log into the app Hello");
        }
    }

    public class LocationType : ObjectGraphType<Location>
    {
        public LocationType()
        {
            Name = "LocationType";
            Description = "Location to be shown on the map";
            Field(x => x.location).Description("Name of the location");
            Field(x => x.longitude).Description("Longitude of the project");
            Field(x => x.latitude).Description("Latitude of the location");
        }
    }
}
