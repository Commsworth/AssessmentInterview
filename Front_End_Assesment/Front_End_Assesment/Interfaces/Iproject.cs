using Front_End_Assesment.Payload;
using Front_End_Assesment.Repositories;
using Front_End_Assesment.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Front_End_Assesment.Interfaces
{
    public interface Iproject
    {
        loginResp UserLogin(loginPayload loginDetails);
        List<Location> LoadLocation();
        genericResp CreateProject(CreateProjectPayload projectInfo);
        IEnumerable<LoadProjectResp> LoadProject();
    }
}
