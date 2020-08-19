using System;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using IdentityServer4.Stores.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Service;

namespace Plus.Infrastructure.IdentityServer.Core.Stors
{

    public class PlusDeviceFlowStore : IDeviceFlowStore
    {
        private readonly IIdentityPersistedGrantDbContext _context;
        private readonly IPersistentGrantSerializer _serializer;
        private readonly ILogger _logger;

      
        public PlusDeviceFlowStore(
            IIdentityPersistedGrantDbContext context, 
            IPersistentGrantSerializer serializer, 
            ILogger<PlusDeviceFlowStore> logger)
        {
            _context = context;
            _serializer = serializer;
            _logger = logger;
        }

      
        public Task StoreDeviceAuthorizationAsync(string deviceCode, string userCode, DeviceCode data)
        {
            _context.DeviceFlowCodes.Add(ToEntity(data, deviceCode, userCode));

            _context.SaveChanges();

            return Task.FromResult(0);
        }

       
        public Task<DeviceCode> FindByUserCodeAsync(string userCode)
        {
            var deviceFlowCodes = _context.DeviceFlowCodes.AsNoTracking().FirstOrDefault(x => x.UserCode == userCode);
            var model = ToModel(deviceFlowCodes?.Data);

            _logger.LogDebug("{userCode} found in database: {userCodeFound}", userCode, model != null);

            return Task.FromResult(model);
        }

       
        public Task<DeviceCode> FindByDeviceCodeAsync(string deviceCode)
        {
            var deviceFlowCodes = _context.DeviceFlowCodes.AsNoTracking().FirstOrDefault(x => x.DeviceCode == deviceCode);
            var model = ToModel(deviceFlowCodes?.Data);

            _logger.LogDebug("{deviceCode} found in database: {deviceCodeFound}", deviceCode, model != null);

            return Task.FromResult(model);
        }

      
        public Task UpdateByUserCodeAsync(string userCode, DeviceCode data)
        {
            var existing = _context.DeviceFlowCodes.SingleOrDefault(x => x.UserCode == userCode);
            if (existing == null)
            {
                _logger.LogError("{userCode} not found in database", userCode);
                throw new InvalidOperationException("Could not update device code");
            }

            var entity = ToEntity(data, existing.DeviceCode, userCode);
            _logger.LogDebug("{userCode} found in database", userCode);

            existing.SubjectId = data.Subject?.FindFirst(JwtClaimTypes.Subject).Value;
            existing.Data = entity.Data;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogWarning("exception updating {userCode} user code in database: {error}", userCode, ex.Message);
            }

            return Task.FromResult(0);
        }

       
        public Task RemoveByDeviceCodeAsync(string deviceCode)
        {
            var deviceFlowCodes = _context.DeviceFlowCodes.FirstOrDefault(x => x.DeviceCode == deviceCode);

            if(deviceFlowCodes != null)
            {
                _logger.LogDebug("removing {deviceCode} device code from database", deviceCode);

                _context.DeviceFlowCodes.Remove(deviceFlowCodes);

                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    _logger.LogInformation("exception removing {deviceCode} device code from database: {error}", deviceCode, ex.Message);
                }
            }
            else
            {
                _logger.LogDebug("no {deviceCode} device code found in database", deviceCode);
            }

            return Task.FromResult(0);
        }

        private DeviceFlowCodes ToEntity(DeviceCode model, string deviceCode, string userCode)
        {
            if (model == null || deviceCode == null || userCode == null) return null;

            return new DeviceFlowCodes
            {
                DeviceCode = deviceCode,
                UserCode = userCode,
                ClientId = model.ClientId,
                SubjectId = model.Subject?.FindFirst(JwtClaimTypes.Subject).Value,
                CreationTime = model.CreationTime,
                Expiration = model.CreationTime.AddSeconds(model.Lifetime),
                Data = _serializer.Serialize(model)
            };
        }

        private DeviceCode ToModel(string entity)
        {
            if (entity == null) return null;

            return _serializer.Deserialize<DeviceCode>(entity);
        }
    }
}