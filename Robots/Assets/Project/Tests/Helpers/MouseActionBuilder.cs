using NSubstitute;
using Project.Scripts;
using Project.Scripts.Player;
using UnityEngine;

namespace Project.Tests.Helpers
{
    internal class MouseActionBuilder
    {
        private MouseAction _mouseAction;
        private IRayCastInteractor _rayCastInteractor;
        private IRayCastMover _rayCastMover;
        private Interactable _target;

        public void Deconstruct(out MouseAction action, out IRayCastMover rayCastMover, out IRayCastInteractor interactor)
        {
            Build();
            action = _mouseAction;
            rayCastMover = _rayCastMover;
            interactor = _rayCastInteractor;
        }

        internal MouseActionBuilder SetInteractionTarget(Interactable target)
        {
            _target = target;
            return this;
        }

        private void Build()
        {
            _rayCastMover = Substitute.For<IRayCastMover>();
            _rayCastInteractor = Substitute.For<IRayCastInteractor>();
            _rayCastInteractor.Target.Returns(_target);
            _rayCastInteractor.HasTarget().Returns(_target != null);
            _mouseAction = new GameObject().AddComponent<MouseAction>();
            _mouseAction.Init(_rayCastMover, _rayCastInteractor);
        }
    }
}