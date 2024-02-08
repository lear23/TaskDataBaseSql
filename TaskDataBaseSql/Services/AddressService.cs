

using System.Diagnostics;
using System.Linq.Expressions;
using TaskDataBaseSql.Entities;
using TaskDataBaseSql.PlayerRepo;

namespace TaskDataBaseSql.Services;

public class AddressService
{
    private readonly AddressRepo _addressRepo;

    public AddressService(AddressRepo addressRepo)
    {
        _addressRepo = addressRepo;
    }

    public AddressEntity CreateAddress(string streetName , string postalCode, string city)
    {
        try
        {
            var addressEntity = _addressRepo.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city  );
            if (addressEntity == null)
            {
                {
                    addressEntity = _addressRepo.Create(new AddressEntity {
                        StreetName = streetName,
                        PostalCode = postalCode,
                        City = city
                    });
                }
            }
            return addressEntity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateRoleService :: " + ex.Message); }
        return null!;
    }
    public AddressEntity GetRoleByName(string streetName, string postalCode, string city)
    {
        try
        {
            var addressEntity = _addressRepo.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            return addressEntity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateGetRoleService :: " + ex.Message); }
        return null!;

    }

    public AddressEntity GetAddressById(int id)
    {
        try
        {
            var addressEntity = _addressRepo.Get(x => x.Id == id);
            return addressEntity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR GetIdAddressService :: " + ex.Message); }
        return null!;
    }
    public IEnumerable<AddressEntity> GetAllAddresses()
    {
        try
        {
            var addresses = _addressRepo.GetAll();
            return addresses;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateGetAllAddressService :: " + ex.Message); }
        return null!;
    }


    public AddressEntity UpdateRole(AddressEntity addressEntity)
    {
        try
        {
            var updateAddress = _addressRepo.Update(x => x.Id == addressEntity.Id, addressEntity);
            return updateAddress;

        }
        catch (Exception ex) { Debug.WriteLine("ERROR UpdateRoleService :: " + ex.Message); }
        return null!;
    }

    //public void DeleteRole(int id)
    //{
    //    try
    //    {
    //        _addressRepo.Delete(x => x.Id == id);

    //    }
    //    catch (Exception ex) { Debug.WriteLine("ERROR DeleteAddressService :: " + ex.Message); }

    //}


    public bool DeleteRole(Expression<Func<AddressEntity, bool>> expression)
    {
        try
        {
            var result = _addressRepo.Delete(expression);
            return result;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR DeleteAddressService :: " + ex.Message); }
        return false;

    }



}
