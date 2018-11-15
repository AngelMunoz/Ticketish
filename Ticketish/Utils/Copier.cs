﻿using System.Linq;

namespace Ticketish.Utils
{
  public static class Copier
  {
    public static void CopyPropertiesTo<T, TU>(this T source, TU dest)
    {
      var sourceProps = typeof(T).GetProperties()
        .Where(x => x.CanRead)
        .ToList();
      var destProps = typeof(TU).GetProperties()
        .Where(x => x.CanWrite)
        .ToList();

      foreach (var sourceProp in sourceProps)
      {
        if (destProps.Any(x => x.Name == sourceProp.Name))
        {
          var p = destProps.First(x => x.Name == sourceProp.Name);
          if (p.Name != "Password")
          { // check if the property can be set or no.
            p.SetValue(dest, sourceProp.GetValue(source, null), null);
          }
        }

      }

    }
  }
}