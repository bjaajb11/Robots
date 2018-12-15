using System;
using NSubstitute;
using Project.Scripts;
using UnityEngine;

namespace Project.Tests.Helpers
{
    internal class RayCastInteractorBuilder
    {
        private Interactable _target;
        private Action<ICameraRayCast> _getCameraRayCast;

        internal RayCastInteractorBuilder SetHitTarget(Interactable target)
        {
            _target = target;
            return this;
        }

        internal RayCastInteractorBuilder GetRayCaster(Action<ICameraRayCast> getAction)
        {
            _getCameraRayCast = getAction;
            return this;
        }

        public static implicit operator RayCastInteractor(RayCastInteractorBuilder builder)
        {
            return builder.Build();
        }

        internal RayCastInteractor Build()
        {
            var rayCaster = Substitute.For<ICameraRayCast>();
            rayCaster.GetHitObject<Interactable>(Arg.Any<Vector3>())
                .Returns(t => _target);
            var interactor = new GameObject().AddComponent<RayCastInteractor>();
            interactor.Init(rayCaster);
            _getCameraRayCast?.Invoke(rayCaster);
            return interactor;
        }
    }
}