using Core.Exceptions.Types;
using Core.Rules;
using Repositories.Abstracts;

namespace Business.Rules
{
    public class BrandBusinessRules:BaseBusinessRules
    {
        private readonly IBrandRepository _brandRepository;

        public BrandBusinessRules(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public void CheckIfBrandNameIsUnique(string name)
        {
            var existingBrand = _brandRepository.Get(b => b.Name == name);
            if (existingBrand != null)
                throw new BusinessException($"{name} adında zaten bir marka var");
        }
    }
}
