using Core.DTO;
using Core.Entities;
using Core.Interfaces;
using Dapper;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Transactions;

namespace Core.Services;

public partial class Service
{
    public async Task<Conquistador> GetConquistadorByUsuarioAsync(int id)
    {
        try
        {
            return await _conquistadorRepository.GetByUsuarioAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Conquistador> GetConquistadorByConqIdAsync(int ConqId)
    {
        try
        {
            return await _conquistadorRepository.GetByConqIdAsync(ConqId);
        }
        catch { throw; }
    }

    public async Task<ICollection<ConquistadorList_DTO>> GetConquistadoresAsync(string sp, DynamicParameters parameters)
    {
        try
        {
            return await _conquistadorRepository.GetAllAsync(sp, parameters);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> AddConquistadorAsync(Conquistador conquistador)
    {
        try
        {
            return await _conquistadorRepository.AddAsync(conquistador);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> UpdateConquistadorAsync(Conquistador conquistador)
    {
        try
        {
            return await _conquistadorRepository.UpdateAsync(conquistador);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> SaveConquistadorAsync(ConquistadorDTO conquistadorDTO, string pass, string UsuaUsuario, string AudiHost)
    {
        bool result = true;
        try
        {
            using (TransactionScope tran = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                Usuario usuario = new Usuario();
                conquistadorDTO.Usuario!.CopyTo(ref usuario);
                usuario.UsuaContrasenia = pass;
                usuario.UsuaCambiarContrasenia = true;
                if (usuario.UsuaId > 0)
                {
                    if (!string.IsNullOrEmpty(conquistadorDTO.Usuario.UsuaContrasenia))
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
                            RoleId = 6,
                            AudiUserCrea = UsuaUsuario,
                            AudiHostCrea = AudiHost,
                        };
                        result = await _rolUsuarioRepository.AddAsync(usuarioRol);
                    }
                }
                if (result)
                {
                    Conquistador conquistador = new Conquistador();
                    conquistadorDTO!.CopyTo(ref conquistador);
                    conquistador.UsuaId = usuario.UsuaId;
                    if (conquistador.PersId > 0)
                    {
                        conquistador.AudiUserMod = UsuaUsuario;
                        conquistador.AudiHostMod = AudiHost;
                        result = await _conquistadorRepository.UpdateAsync(conquistador);
                    }
                    else
                    {
                        conquistador.AudiUserCrea = UsuaUsuario;
                        conquistador.AudiHostCrea = AudiHost;
                        result = await _conquistadorRepository.AddAsync(conquistador);
                    }
                    if (result)
                    {
                        FichaMedica fichaMedica = new FichaMedica();
                        conquistadorDTO.ConqFichaMedica!.CopyTo(ref fichaMedica);
                        fichaMedica.ConqId = conquistador.PersId;
                        fichaMedica.FimeAnio = DateTime.Now.Year;
                        fichaMedica.AudiUserCrea = UsuaUsuario;
                        fichaMedica.AudiHostCrea = AudiHost;
                        result = await _fichaMedicaRepository.SaveAsync(fichaMedica);
                        if (result)
                        {
                            if (conquistadorDTO.ConqTutores != null && conquistadorDTO.ConqTutores.Count > 0)
                            {
                                ICollection<TutorConquistador> tutores = new List<TutorConquistador>();
                                foreach (var item in conquistadorDTO.ConqTutores)
                                {
                                    TutorConquistador tc = new TutorConquistador()
                                    {
                                        ConqId = conquistador.PersId,
                                        TutoId = item.PersId!.Value,
                                        TucoTipoParentescoTabla = "PAR",
                                        TucoTipoParentescoId = item.PersSexo!.Equals("M") ? 1 : 2,
                                        AudiUserCrea = UsuaUsuario,
                                        AudiHostCrea = AudiHost,
                                    };
                                    tutores.Add(tc);
                                }
                                result = await _tutorConquistadorRepository.AddListAsync(tutores);
                            }
                        }
                        if (result)
                        {
                            if(conquistadorDTO.ConqClase != null && conquistadorDTO.ConqClase.ClasId > 0)
                            {
                                ClaseConquistador claseConquistador = new ClaseConquistador()
                                {
                                    ClasId = conquistadorDTO.ConqClase.ClasId.Value,
                                    ConqId = conquistador.PersId,
                                    ClcoAnio = DateTime.Now.Year,
                                    ClcoTipoCargoClaseTabla = "CLA",
                                    ClcoTipoCargoClaseId = 2,
                                    AudiUserCrea = UsuaUsuario,
                                    AudiHostCrea = AudiHost,
                                };
                                result = await _claseConquistadorRepository.SaveAsync(claseConquistador);
                            }
                        }
                        if (result)
                        {
                            if(conquistadorDTO.ConqUnidad!=null && conquistadorDTO.ConqUnidad.UnidId > 0)
                            {
                                UnidadConquistador unidadConquistador = new UnidadConquistador()
                                {
                                    UnidId = conquistadorDTO.ConqUnidad.UnidId.Value,
                                    ConqId = conquistador.PersId,
                                    UncoAno = DateTime.Now.Year,
                                    UncoCargoTabla = "UND",
                                    UncoCargoId = conquistadorDTO.ConqUnidad.UncoCargoId.Value,
                                    AudiUserCrea = UsuaUsuario,
                                    AudiHostCrea = AudiHost,
                                };
                                result = await _unidadConquistadorRepository.SaveAsync(unidadConquistador);
                            }
                        }
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

    public async Task<ConquistadorRegistroDTO> GetRegistroConquistadorAsync(int ConqId)
    {
        try
        {
            return await _conquistadorRepository.GetRegistroConquistadorAsync(ConqId);
        }
        catch { throw; }
    }

    public async Task<ICollection<ConquistadorFichaMedicaDTO>> GetFichaMedicaConquistadorAsync(int ConqId)
    {
        try
        {
            return await _conquistadorRepository.GetFichaMedicaConquistadorAsync(ConqId);
        }
        catch { throw; }
    }
}