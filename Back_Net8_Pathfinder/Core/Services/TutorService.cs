using Core.DTO;
using Core.Entities;
using Core.Interfaces;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Transactions;

namespace Core.Services;

public partial class Service
{
    public async Task<Tutor> GetTutorByUsuarioAsync(int id)
    {
        try
        {
            return await _tutorRepository.GetByUsuarioAsync(id);
        }
        catch { throw; }
    }

    public async Task<ICollection<Tutor>> GetAllTutoresAsync()
    {
        try
        {
            return await _tutorRepository.GetAllAsync();
        }
        catch { throw; }
    }

    public async Task<ICollection<Tutor>> GetAllTutoresBySexoAsync(string PersSexo)
    {
        try
        {
            return await _tutorRepository.GetAllBySexoAsync(PersSexo);
        }
        catch { throw; }
    }

    public async Task<ICollection<Tutor>> GetAllTutoresByConqIdAsync(int ConqId)
    {
        try
        {
            return await _tutorRepository.GetAllByConqIdAsync(ConqId);
        }
        catch { throw; }
    }

    public async Task<Tutor> GetTutorByIdAsync(int TutoId)
    {
        try
        {
            return await _tutorRepository.GetByIdAsync(TutoId);
        }
        catch { throw; }
    }

    public async Task<bool> AddTutorAsync(Tutor tutor)
    {
        try
        {
            return await _tutorRepository.AddAsync(tutor);
        }
        catch { throw; }
    }

    public async Task<bool> UpdateTutorAsync(Tutor tutor)
    {
        try
        {
            return await _tutorRepository.UpdateAsync(tutor);
        }
        catch { throw; }
    }

    public async Task<bool> SaveTutorAsync(TutorDTO tutorDTO, string pass, string UsuaUsuario, string AudiHost)
    {
        bool result = true;
        try
        {
            using(TransactionScope tran =  new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                Usuario usuario = new Usuario();
                tutorDTO.Usuario!.CopyTo(ref usuario);
                usuario.UsuaContrasenia = pass;
                usuario.UsuaCambiarContrasenia = true;
                if (usuario.UsuaId > 0)
                {
                    if (!string.IsNullOrEmpty(tutorDTO.Usuario.UsuaContrasenia))
                    {
                        usuario.AudiUserMod = UsuaUsuario;
                        usuario.AudiHostMod = AudiHost!;
                        result = await _usuarioRepository.UpdateAsync(usuario);
                    }
                }
                else
                {
                    usuario.AudiUserCrea = UsuaUsuario;
                    usuario.AudiHostCrea = AudiHost;
                    result = await _usuarioRepository.AddAsync(usuario);
                    if (result)
                    {
                        UsuarioRol usuarioRol = new UsuarioRol()
                        {
                            UsuaId = usuario.UsuaId,
                            RoleId = 5,
                            AudiUserCrea = UsuaUsuario,
                            AudiHostCrea = AudiHost,
                        };
                        result = await _rolUsuarioRepository.AddAsync(usuarioRol);
                    }
                }
                if (result)
                {
                    Tutor tutor = new Tutor();
                    tutorDTO!.CopyTo(ref tutor);
                    tutor.UsuaId = usuario.UsuaId;
                    if (tutor.PersId > 0)
                    {
                        tutor.AudiUserMod = UsuaUsuario;
                        tutor.AudiHostMod = AudiHost;
                        result = await _tutorRepository.UpdateAsync(tutor);
                    }
                    else
                    {
                        tutor.AudiUserCrea = UsuaUsuario;
                        tutor.AudiHostCrea = AudiHost;
                        result = await _tutorRepository.AddAsync(tutor);
                    }
                }
                if (result)
                {
                    tran.Complete();
                }
                return result;
            }
        }
        catch { throw; }
    }
}