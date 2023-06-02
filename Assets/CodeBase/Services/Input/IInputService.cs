using UnityEngine;

namespace Assets.CodeBase.Services.Input
{
    public  interface IInputService
    {
        Vector2 Axis { get; }

        bool IsAttackButtonUp();
    }
}