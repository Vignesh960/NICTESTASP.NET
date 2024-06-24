using AutoMapper;
using NICRegister.Models;

namespace NICRegister.Automaping
{
    public class Automapping:Profile
    {
        public Automapping()
        {
            CreateMap<Register, AddRegister>().ReverseMap();
        }
    }
}
