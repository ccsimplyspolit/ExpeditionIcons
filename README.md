# ExpeditionIcons — PoE2

Expedition encounter overlay and optional path planner for ExileCore2.

## What it does

- Classifies PoE2 Expedition markers, chests, relics, detonator state, and
  encounter metadata.
- Draws world icons, labels, explosive radii, minimap/large-map markers, and
  optional planner routes.
- Scores routes with user-configured terrain, distance, and loot weights.

## Logic

`Initialise` loads icons/settings and registers lifecycle handlers. `Tick`
refreshes encounter state and map geometry. A planner request snapshots the
current encounter and runs on a cancellable worker; a validated result is
published back to the main thread. `Render` consumes the snapshot and draws the
icons/radii/route. Area changes, disable, hot reload, and dispose cancel workers
and clear stale state. It is read-only and performs no game input.

Entity reads fail closed when ExileCore2 has not populated an `EntityType` bucket
yet, which is common during startup and area transitions. Cancelling a planner
also suppresses its completion sound, so stopping a search or unloading the
plugin cannot report a false successful route.

## Status

Build: **PASS**. Classification: **CURRENT_WITH_WARNINGS**; a live current-league
Expedition and logbook test is still required.

Detailed report: [PoE2 plugin catalog](../../README.md) ·
[audit](../../../docs/plugins/ExpeditionIcons/AUDIT.md).
