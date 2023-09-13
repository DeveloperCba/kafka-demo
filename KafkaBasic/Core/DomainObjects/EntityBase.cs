using System;
using System.ComponentModel.DataAnnotations;

namespace Core.DomainObjects;

public abstract class EntityBase
{
    [Key]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public EntityBase()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
    }

    public virtual bool EhValido()
    {
        throw new NotImplementedException();
    }

    #region Comparações
    //Método Qual para comprarção de instância
    public override bool Equals(object obj)
    {
        var compareTo = obj as EntityBase;

        if (ReferenceEquals(this, compareTo)) return true;
        if (ReferenceEquals(null, compareTo)) return false;

        return Id.Equals(compareTo.Id);
    }


    //Configura o operador == para fazer compração de instância
    public static bool operator ==(EntityBase a, EntityBase b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }

    //Configura o operador != para fazer compração de instância
    public static bool operator !=(EntityBase a, EntityBase b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return GetType().GetHashCode() * 907 + Id.GetHashCode();
    }

    public override string ToString()
    {
        return $"{GetType().Name} [Id={Id}]";
    }

    #endregion

}