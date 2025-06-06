public enum RelationshipType
{
    Ally,
    Enemy,
    Neutral
}

public static class FactionRelations
{
    public static RelationshipType GetRelationship(FactionType a, FactionType b)
    {
        if (a == b) return RelationshipType.Ally;

        // Aquí defines quién es enemigo de quién
        if ((a == FactionType.Player1 && b == FactionType.Player2) ||
            (a == FactionType.Player2 && b == FactionType.Player1))
            return RelationshipType.Enemy;

        return RelationshipType.Neutral;
    }
}
