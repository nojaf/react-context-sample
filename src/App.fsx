#load "../.paket/load/netstandard2.0/main.group.fsx"

#if INTERACTIVE
#r "netstandard"
#endif

#load "./UserContext.fsx"

open Fable.React
open UserContext

type TitleProps = { key: obj }

let Title = 
    (fun (props: TitleProps) ->
        let userContextValue = useContext(UserContext)
        printfn "UserContextValue: %A" userContextValue

        p [] [
                str "User in context:"
                strong [] [ str userContextValue.User ]
        ]
    )
    |> FunctionComponent.Of

let app =
    provider [
        Title ({key="title key"})
    ]

mountById "app" app