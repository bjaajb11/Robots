﻿namespace Project.Tests.Helpers
{
    internal static class Data
    {
        public static AttackSkillBuilder AttackSkill => new AttackSkillBuilder();

        public static RayCastInteractorBuilder RayCastInteractor =>
            new RayCastInteractorBuilder();

        public static MouseActionBuilder MouseAction => new MouseActionBuilder();
    }
}