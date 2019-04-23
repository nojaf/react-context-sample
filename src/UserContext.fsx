#load "../.paket/load/netstandard2.0/main.group.fsx"

#if INTERACTIVE
#r "netstandard"
#endif

open Fable.React
open Fable.Core
open Fable.Core.JsInterop

// Bindings
type Context<'t> = 
    [<Emit("React.createElement($0.Provider, { value: $1}, $2)")>]
    member this.Provider (value:'t option) (children: ReactElement seq) : ReactElement = jsNative

let createContext<'t> (defaultValue: 't) : Context<'t> = import "createContext" "react"
let useContext<'t> (context: Context<'t>) : 't = import "useContext" "react" 

// Usage
type UserContextValue = { User: string }

let UserContext = createContext { User = "default" }

let provider (children: ReactElement seq) = 
    UserContext.Provider (Some { User = "nojaf" }) children