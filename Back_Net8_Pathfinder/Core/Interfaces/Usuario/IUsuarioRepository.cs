﻿using Core.Entities;

namespace Core.Interfaces;

public interface IUsuarioRepository
{
    Task<Usuario> GetByIdAsync(int id);
    Task<Usuario> GetByUsernameAsync(string username);
    Task<bool> AddAsync(Usuario usuario);
    Task<bool> UpdateAsync(Usuario usuario);
    Task<ICollection<Usuario>> GetAllAsync();
}