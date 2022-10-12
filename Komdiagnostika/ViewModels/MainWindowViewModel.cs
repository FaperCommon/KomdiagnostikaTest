using AutoMapper;
using BLL.DTOs;
using BLL.Services.Interfaces;
using Komdiagnostika.Models;
using Komdiagnostika.Views;
using Microsoft.EntityFrameworkCore;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Komdiagnostika.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;
        private IStoreService _storeService;
        private IDialogService _dialogService;
        private IMapper _mapper;

        private StoreModel _selectedStore;
        public ObservableCollection<StoreModel> _stores { get; set; }

        public StoreModel SelectedStore
        {
            get => _selectedStore;
            set
            {
                _selectedStore = value;

                EditStoreCommand?.RaiseCanExecuteChanged();
                RemoveStoreCommand?.RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<StoreModel> Stores
        {
            get => _stores;
            set
            {
                _stores = value;

                RaisePropertyChanged();
            }
        }

        public DelegateCommand AddStoreCommand { get; set; }
        public DelegateCommand EditStoreCommand { get; set; }
        public DelegateCommand RemoveStoreCommand { get; set; }

        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator eventAggregator,
            IStoreService storeService, IDialogService dialogService)
        {
            _eventAggregator = eventAggregator;
            _regionManager = regionManager;
            _storeService = storeService;
            _dialogService = dialogService;

            Title = "Komdiagnostika";

            Initialize();
        }

        private void Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StoreModel, StoreDTO>();
                cfg.CreateMap<StoreDTO, StoreModel>();
            });

            _mapper = config.CreateMapper();

            Stores = new ObservableCollection<StoreModel>(_mapper.Map<IEnumerable<StoreDTO>, IEnumerable<StoreModel>>(_storeService.GetAll()));

            AddStoreCommand = new DelegateCommand(() =>
            {
                ShowStoreView(EntityState.Added);
            },
                () => true
            );

            EditStoreCommand = new DelegateCommand(() =>
            {
                ShowStoreView(EntityState.Modified);
            },
                () => SelectedStore != null
            );

            RemoveStoreCommand = new DelegateCommand(() =>
            {
                DbStoreUpdate(EntityState.Deleted, SelectedStore);
            },
                () => SelectedStore != null
            );
        }

        private void ShowStoreView(EntityState state)
        {
            if(state == EntityState.Added)
            {
                var store = new StoreModel();
                SelectedStore = store;
            }

            var parameters = new DialogParameters();

            parameters.Add("Store", SelectedStore);

            _dialogService.ShowDialog(nameof(StoreView), parameters, (result) => {
                CloseDialogCallback(result, state);
            });
        }

        private void CloseDialogCallback(IDialogResult dialogResult, EntityState state)
        {
            var isSuccess = dialogResult.Parameters.GetValue<bool>("isSuccess");

            if (isSuccess)
            {
                DbStoreUpdate(state, SelectedStore);
            }
        }

        private void DbStoreUpdate(EntityState state, StoreModel store)
        {
            switch (state)
            {
                case EntityState.Added:
                    _storeService.Add(_mapper.Map<StoreModel, StoreDTO>(store));
                    break;
                case EntityState.Deleted:
                    _storeService.Delete(_mapper.Map<StoreModel, StoreDTO>(store));
                    Stores.Remove(store);
                    break;
                case EntityState.Modified:
                    _storeService.Update(_mapper.Map<StoreModel, StoreDTO>(store));
                    break;
                default:
                    throw new Exception("[MainWindowViewModel] EntityState undefined");
            }

            Stores = new ObservableCollection<StoreModel>(_mapper.Map<IEnumerable<StoreDTO>, IEnumerable<StoreModel>>(_storeService.GetAll()));
        }
    }
}
