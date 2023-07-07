using Temps.DTO;

namespace Temps.SRV
{
    public interface IMachine_SRV<Type_DTO> 
        where Type_DTO : Machine_DTO
    {
        Type_DTO GetById(int id);
        IEnumerable<Type_DTO> GetAll();
        Type_DTO Ajouter(Type_DTO machine);
        Type_DTO Modifier(Type_DTO machine);
        Type_DTO ModifierSignal(Type_DTO machine);
        void Supprimer(int id);
    }
}