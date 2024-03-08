﻿using VotifySystem.Classes.Elections;

namespace VotifySystem.BusinessLogic.Services;

/// <summary>
/// 
/// </summary>
internal interface IElectionService
{
    void SaveElection();
    List<Election> GetElectionsByCandidateId(string candidateId);
    List<Election> GetElectionsByElectionCandidate(string candidateId, string electionId);
}