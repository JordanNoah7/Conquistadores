﻿using System.Collections.ObjectModel;
using Core.Entities;
using Core.Interfaces;

namespace Core.Services;

public partial class Service
{
    public async Task<Usuario> GetUserByIdAsync(int id)
    {
        try
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Usuario> GetUserByUsernameAsync(string username)
    {
        try
        {
            return await _usuarioRepository.GetByUsernameAsync(username);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> UpdateUsuarioAsync(Usuario usuario)
    {
        try
        {
            return await _usuarioRepository.UpdateAsync(usuario);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}