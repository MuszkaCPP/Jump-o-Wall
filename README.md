\documentclass{article}
\usepackage[utf8]{inputenc}
\usepackage[margin=1.5cm]{geometry}
\usepackage{enumerate}
\usepackage{graphicx}
\usepackage{multicol}
\usepackage{verbatim}
\usepackage{listings}

\frenchspacing
\linespread{1.2}
\geometry{top=1mm}
\setlength{\parindent}{0pt}
\title{Jump'o Wall}
\author{}
\date{}

\begin{document}

\maketitle

\section{Game Mechanics}
\begin{itemize}
    \item player has to pass certain levels, segregated by difficulty
    \item player has \textbf{Heatlh points}, that can be lost by objects giving some damage
    \item every move is simulated by physics implemented in Unity Engine
\end{itemize}
\section{Graphics}
    \begin{itemize}
        \item +/- pixel art (32x32, 64x64)
        \item free Unity Store assets
    \end{itemize}
\section{Audio}
    \begin{itemize}
        \item TBA
    \end{itemize}
\section{Technologies}
    \begin{itemize}
        \item Unity 2019.4.0f1
        \item Fire Alpaca
        \item Visual Studio Code
        \item git
    \end{itemize}
\section{Production process}
    \begin{itemize}
        \item TBA
    \end{itemize}
    
\section{Progress}
\begin{itemize}
    \item \textbf{Week 1}: 22-28.06.2020
        \begin{itemize}
            \item \textbf{25.06.2020}
                \begin{itemize}
                    \item added alpha version of player movement
                    \item added player texture
                    \item added pre-version of colliding objects
                    \item added PlayerController, PlayerMover, MainPlayer, GameManager
                    \item added LevelEnder class (2D collider searching for Player entry);
                \end{itemize}
            \end{itemize}
\end{itemize}


\end{document}
