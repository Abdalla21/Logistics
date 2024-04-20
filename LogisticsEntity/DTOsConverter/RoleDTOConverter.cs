using LogisticsDataCore.DTOs;
using LogisticsDataCore.Tables;

namespace LogisticsEntity.DTOsConverter
{
    public static class RoleDTOConverter
    {
        public static RolesDTO ConvertRoleToRoleDto(this Role role, string roleName, string roleDesc)
        {

            RolesDTO roleDTO = new RolesDTO
            (
                roleName,
                roleDesc
            );

            return roleDTO;
        }

        public static List<RolesDTO> ConvertRolesToRolesDto(List<Role> roles)
        {
            List<RolesDTO> rolesDTOs = new List<RolesDTO>();
            
            foreach ( Role r in roles )
            {
                rolesDTOs.Add(new RolesDTO(r.RoleName, r.RoleDescription));
            }

            return rolesDTOs;
        }
    }
}
