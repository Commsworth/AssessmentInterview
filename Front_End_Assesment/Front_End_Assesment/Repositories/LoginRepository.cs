using Front_End_Assesment.Interfaces;
using Front_End_Assesment.Message_Handlers;
using Front_End_Assesment.Models;
using Front_End_Assesment.Payload;
using Front_End_Assesment.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Front_End_Assesment.Repositories
{
    public class ProjectRepository : Iproject
    {
        private IConfiguration config;
        private ProjectContext _context;
        private IHttpContextAccessor _httpContext;
        private string token;

        public ProjectRepository(IConfiguration _config, ProjectContext context, IHttpContextAccessor httpContext)
        {
            this.config = _config;
            _context = context;
            _httpContext = httpContext;
        }
        
        public loginResp UserLogin(loginPayload loginDetails)
        {
            try
            {
                using (var db = _context)
                {
                    if (loginDetails.email == "hello@commsworth.com" && loginDetails.password == "Hello")
                        return new loginResp { message = "Login Succesful", status = true, accessToken = new TokenManager(config).GenerateToken(loginDetails.email) };
                    else
                    {
                        return new loginResp { message = "Login Unsuccesful", status = false };
                    }
                }
            }
            catch (Exception ex)
            {
                return new loginResp { message = "Something went wrong. We are working hard to fix this", status = false };
            }
        }

        public List<Location> LoadLocation()
        {
            try
            {
                var locations = new List<Location>();
                locations.Add(new Payload.Location { latitude = (decimal)5.532003041, longitude = (decimal)7.486002487, location = "Abia"});
                locations.Add(new Payload.Location { latitude = (decimal)6.443261653, longitude = (decimal)3.391531071, location = "Lagos"});
                locations.Add(new Payload.Location { latitude = (decimal)7.629959329, longitude = (decimal)4.179992634, location = "Osun"});
                locations.Add(new Payload.Location { latitude = (decimal)9.083333149, longitude = (decimal)7.533328002, location = "Abuja"});
                locations.Add(new Payload.Location { latitude = (decimal)11.68040977, longitude = (decimal)10.19001339, location = "Bauchi"});
                locations.Add(new Payload.Location { latitude = (decimal)7.250395934, longitude = (decimal)5.199982054, location = "Ondo"});
                locations.Add(new Payload.Location { latitude = (decimal)6.340477314, longitude = (decimal)5.620008096, location = "Edo"});
                locations.Add(new Payload.Location { latitude = (decimal)4.960406513, longitude = (decimal)8.330023558, location = "Crossriver"});
                locations.Add(new Payload.Location { latitude = (decimal)6.867034321, longitude = (decimal)7.383362995, location = "Enugu"});
                locations.Add(new Payload.Location { latitude = (decimal)11.99997683, longitude = (decimal)8.5200378,   location = "Kano"});
                return locations;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public genericResp CreateProject(CreateProjectPayload projectInfo)
        {
            try
            {
                var project = new Project { Budget = projectInfo.Budget, contractorAddress = projectInfo.contractorAddress, contractorName = projectInfo.contractorName, Title = projectInfo.Title, endDate = projectInfo.endDate, startDate = projectInfo.startDate };
                _context.Project.Add(project);
                return new genericResp { message = "Project Created" , status = true };
            }
            catch(Exception Ex)
            {
                return new genericResp { message = "couldn't create new project reason being" + Ex, status = false };
            }
        }

        public IEnumerable<LoadProjectResp> LoadProject()
        {
            using (var db = _context)
            {
                var project = _context.Project.Select(o => new LoadProjectResp { Budget = o.Budget, contractorAddress = o.contractorAddress, contractorName = o.contractorName, endDate = o.endDate, startDate = o.startDate }).ToList();
                return project;
            }
        }
    }
}
