namespace LanchesMac.Services
{
    public interface ISeedUserRoleInitial
    {
        //Implementar a criação dos perfil
        void SeedRoles();
        
        //Implementar para criar os usuários e atribuir os usuários aos perfil
        void SeedUsers();
    }
}
