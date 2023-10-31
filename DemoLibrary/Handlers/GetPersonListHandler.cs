using DemoLibrary.DataAccess;
using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;

namespace DemoLibrary.Handlers
{
    public class GetPersonListHandler : IRequestHandler<GetPersonListQuery, List<PersonModel>>
    {
        private readonly IDataAccess _data;
        public GetPersonListHandler(IDataAccess data)
        {
            _data = data;
        }
        public async Task<List<PersonModel>> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
        {
            List<PersonModel> people = _data.GetPeople();

            return await Task.FromResult(people);
        }
    }
}
