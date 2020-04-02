﻿namespace Sylvester

open FSharp.Quotations

/// Propositional calculus using the axioms and rules of S.
module PropCalculus =
    let prop_calculus = Theory.S

    /// Reduce logical constants in expression. 
    let Reduce = S.Rules.[0]

    /// Logical expression is left associative.
    let LeftAssoc = S.Rules.[1]

    /// Logical expression is right associative.
    let RightAssoc = S.Rules.[2]
  
    /// Logical expression is commutative.
    let Commute = S.Rules.[3]

    /// Distribute logical terms in expression.
    let Distrib = S.Rules.[4]

    /// Collect distributed logical terms in expression.
    let Collect = S.Rules.[5]

    /// Logical operators are idempotent.
    let Idemp = S.Rules.[6]

    /// Logical expression satisfies law of excluded middle.
    let ExcludedMiddle = Theory.S.Rules.[7]

    /// Logical expression satisfies golden rule.
    let GoldenRule = Theory.S.Rules.[8]

    let reduce_constants = EquationalLogic.reduce_constants

    let left_assoc = EquationalLogic.left_assoc

    let right_assoc = EquationalLogic.right_assoc

    let commute = EquationalLogic.commute

    let distrib = EquationalLogic.distrib

    let collect = EquationalLogic.collect

    let idemp = EquationalLogic.idemp

    let excluded_middle = EquationalLogic.excluded_middle

    let golden_rule = EquationalLogic.golden_rule

    (* proof step shortcuts *)
    let eq_id_ax expr = id_ax prop_calculus expr
    let eq_id_ax_lr expr = id_ax_lr prop_calculus expr
    let eq_id_ax_l expr = id_ax_l prop_calculus expr
    let eq_id_ax_r expr = id_ax_r prop_calculus expr

    let eq_id steps expr = ident prop_calculus steps expr 
    let eq_id_lr steps expr = id_lr prop_calculus steps expr
    let eq_id_l steps expr= id_l prop_calculus steps expr
    let eq_id_r steps expr = id_r prop_calculus steps expr

    (* Additional theorems of S useful in proofs. *)

    (*
    /// p = p = true
    let TruthDefn (p:Expr<bool>) = id_ax prop_calculus <@ (%p = %p) = true @>  

    /// not p = p = false
    let FalseDefn (p:Expr<bool>) =  ident prop_calculus <@(not %p = %p) = false@> [
            Collect |> L
            <@(%p = %p) = true @> |> eq_id_ax_l
        ]
                
    /// not false = true
    let NotFalseDefnTrue = 
        let stmt = <@ not false = true @>
        let lemma1 = eq_id <@ true = (false = false) @> [
            LR Commute
            TruthDefn <@ false @> |> L
        ]
        let lemma2 = eq_id <@ (false = false) = true @> [
            TruthDefn <@ false @> |> L
        ]
        eq_id stmt [
            LR Commute
            L lemma1
            LR RightAssoc
            R Commute
            R Collect
            R lemma2 
        ]

    /// not not p == p
    let DoubleNegation (p:Expr<bool>) = ident prop_calculus <@ not (not %p) = %p @>  [
            Collect |> L
            FalseDefn p |> L
        ]

    //let Reflex
    /// not p = q = p = not q
    let NotEquivSymmetry (p:Expr<bool>) (q:Expr<bool>) = theorem prop_calculus <@ not %p = %q = %p = not %q @> [
            Collect |> L
            RightAssoc |> LR
            Commute |> R
            Collect |> R
            Commute |> R
        ] 

    *)