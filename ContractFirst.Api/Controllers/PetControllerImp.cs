using Example.Controllers;
namespace ContractFirst.Controllers;

public class PetControllerImp : IPetController
{
    public Task AddPetAsync(Pet body)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePetAsync(Pet body)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Pet>> FindPetsByStatusAsync(IEnumerable<Anonymous> status)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Pet>> FindPetsByTagsAsync(IEnumerable<string> tags)
    {
        throw new NotImplementedException();
    }

    public Task<Pet> GetPetByIdAsync(long petId)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePetWithFormAsync(long petId, string name, string status)
    {
        throw new NotImplementedException();
    }

    public Task DeletePetAsync(string api_key, long petId)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse> UploadFileAsync(long petId, string additionalMetadata, FileParameter file)
    {
        throw new NotImplementedException();
    }
}