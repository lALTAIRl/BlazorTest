using AutoMapper;

namespace BlazorTest.Identity.Application.Mappings
{
    public interface IMapTo<T>
    {
        public void Mapping(Profile profile) => profile.CreateMap(this.GetType(), typeof(T));
    }
}
