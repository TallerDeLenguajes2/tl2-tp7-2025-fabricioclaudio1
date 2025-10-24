public interface IProductoRepository
{
User FindById(int id);
IEnumerable FindAll();
void Insert(User usuario);
void Update(User usuario);
void Delete(int idUsuario);
}