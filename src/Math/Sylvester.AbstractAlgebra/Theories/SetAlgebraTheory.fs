﻿namespace Sylvester

module SetAlgebraTheory =
    open BooleanAlgebraTheory    
    let set_algebra<'t when 't: equality> = BooleanAlgebraTheory(<@Set.(|+|)@>, <@Set.(|*|)@>, Set.Empty, Set.U<'t>, <@id@>)

    let ReduceIdemp = set_algebra.Rules.[0]

    let ReduceIdent = set_algebra.Rules.[1]

    let ReduceComp = set_algebra.Rules.[2]

    let LeftAssoc = set_algebra.Rules.[3]

    let RightAssoc = set_algebra.Rules.[4]

    let Commute = set_algebra.Rules.[5]

    let Distrib = set_algebra.Rules.[6]