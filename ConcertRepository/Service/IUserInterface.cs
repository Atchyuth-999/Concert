using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcertRepository.Model;

namespace ConcertRepository.Interfaces
{
    public interface IUserInterface
    {
        bool RegisterUser(UserDTO user);

        List<UserDTO> GetAllUsers();

        bool UpdateUser(UserDTO user);

        UserDTO GetUserById(int registrationId);
        bool DeleteUser(int registrationId);
    }
}