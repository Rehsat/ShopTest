using UnityEngine;
using Zenject;

namespace Inventories.Zenject
{
    public class ActiveInventoriesInstaller : MonoInstaller
    {
        [SerializeField] private ActiveInventoriesData _inventoriesData;
        public override void InstallBindings()
        {
            Container.Bind<ActiveInventoriesData>().FromInstance(_inventoriesData).AsSingle();
        }
    }
}