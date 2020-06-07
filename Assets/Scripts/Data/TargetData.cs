using Unity.Entities;

[GenerateAuthoringComponent]
public class TargetData : IComponentData
{
    public Entity targetEntity;
}
