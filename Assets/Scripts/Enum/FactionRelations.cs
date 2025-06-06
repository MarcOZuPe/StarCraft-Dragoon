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

        // Aqu� defines qui�n es enemigo de qui�n
        if ((a == FactionType.Player1 && b == FactionType.Player2) ||
            (a == FactionType.Player2 && b == FactionType.Player1))
            return RelationshipType.Enemy;

        return RelationshipType.Neutral;
    }
}
