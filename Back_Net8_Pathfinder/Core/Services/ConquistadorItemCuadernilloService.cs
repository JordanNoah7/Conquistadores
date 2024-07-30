namespace Core.Services;

public partial class Service
{
    public async Task<decimal> GetAvanceConquistadorAsync(int ConqId)
    {
        try
        {
            return await _conquistadorItemCuadernilloRepository.GetAvanceAsync(ConqId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
