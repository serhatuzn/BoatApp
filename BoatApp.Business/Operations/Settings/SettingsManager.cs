using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatApp.Data.Entites;
using BoatApp.Data.Repositories;
using BoatApp.Data.UnitOfWork;

namespace BoatApp.Business.Operations.Settings
{
    public class SettingsManager : ISettingsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<SettingsEntity> _settingsRepository;


        public SettingsManager(IUnitOfWork unitOfWork, IRepository<SettingsEntity> settingsRepository)
        {
            _unitOfWork = unitOfWork;
            _settingsRepository = settingsRepository;
        }

        public bool GetMaintenenceMode()
        {
            var mainState = _settingsRepository.Find(1).MaintenenceMode;

            return mainState;
        }

        public async Task ToogleMaintenence()
        {
            var settings = _settingsRepository.Find(1);
            
            settings.MaintenenceMode = !settings.MaintenenceMode; // Burada her zaman tersini alıyoruz true'sa false, false'sa true olacak.

            _settingsRepository.Update(settings);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Durum güncellenirken bir hata ile karşılaşıldı", ex);
            }
        }
    }
}
