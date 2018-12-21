using NSubstitute;
using NUnit.Framework;
using Project.Scripts;
using Project.Scripts.Character;
using Project.Scripts.Player;
using Project.Scripts.Skills;
using Project.Tests.Helpers;
using UnityEngine;

public class MouseActionSpec
{
    public class DoMouseActionTests
    {
        [Test]
        public void Always_MovesToThePosition()
        {
            (MouseAction action, IRayCastMover mover, _) = Data.MouseAction;
            var position = Vector3.up;
            action.DoMouseAction(position, null);
            mover.Received(1).Move(position);
        }

        [Test]
        public void InteractorHasTarget_MovesToTarget()
        {
            var interactable = new GameObject().AddComponent<Interactable>();
            (MouseAction action, IRayCastMover mover, _) = Data.MouseAction.SetInteractionTarget(interactable);

            var position = Vector3.up;
            action.DoMouseAction(position, null);
            mover.Received(1).Move(position, interactable);
        }

        [Test]
        public void Always_UpdatesRayCasterFocus()
        {
            (MouseAction action, _, IRayCastInteractor interactor) = Data.MouseAction;
            var position = Vector3.up;
            action.DoMouseAction(position, null);
            interactor.Received(1).UpdateFocus(position);
        }

        [Test]
        public void HasInRangeTarget_AttacksTargetWithSkill()
        {
            var gameObject = new GameObject();
            var interactable = gameObject.AddComponent<Interactable>();
            var stats = gameObject.AddComponent<CharacterStats>();
            interactable.SetInternals(1f);
            (MouseAction action, _, _) = Data.MouseAction.SetInteractionTarget(interactable);

            var position = Vector3.up;

            var skill = Substitute.For<IAttackSkill>();
            action.DoMouseAction(position, skill);
            skill.Received(1).Attack(stats);
        }

        [Test]
        public void TargetNotInRange_DoesNotAttacksTargetWithSkill()
        {
            var gameObject = new GameObject();
            var interactable = gameObject.AddComponent<Interactable>();
            var stats = gameObject.AddComponent<CharacterStats>();
            interactable.SetInternals(0.2f);
            (MouseAction action, _, _) = Data.MouseAction.SetInteractionTarget(interactable);

            var position = Vector3.up;
            gameObject.transform.position = Vector3.forward;
            var skill = Substitute.For<IAttackSkill>();
            action.DoMouseAction(position, skill);
            skill.Received(0).Attack(stats);
        }
    }
}